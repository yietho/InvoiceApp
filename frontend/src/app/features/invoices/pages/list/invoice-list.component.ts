import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpParams } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../../core/services/auth.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-invoice-list',
  imports: [CommonModule, FormsModule],
  templateUrl: './invoice-list.component.html'
})
export class InvoiceListComponent implements OnInit {
  private http = inject(HttpClient);
  private router = inject(Router);
  private auth = inject(AuthService);
  private route = inject(ActivatedRoute);

  invoices: any[] = [];
  startDate?: string;
  endDate?: string;

  ngOnInit() {
    this.loadInvoices(); 
  }

  loadInvoices() {
    let params = new HttpParams();
    if (this.startDate) {
      params = params.set('startDate', new Date(this.startDate).toISOString());
    }
    if (this.endDate) {
      params = params.set('endDate', new Date(this.endDate).toISOString());
    }

    this.http.get<any[]>('https://localhost:7206/api/invoice/InvoiceList', { params })
      .subscribe({
        next: (res) => this.invoices = res,
        error: (err) => console.error('Failed to load invoices:', err)
      });
  }

  goToCreate() {
    this.router.navigate(['create-invoice'], { relativeTo: this.route });
  }

  canEditOrDelete(invoice: any): boolean {
    const currentUserId = this.auth.getUserId();
    const currentCustomerId = this.auth.getCustomerId();
    return invoice.userId === currentUserId && invoice.customerId === currentCustomerId;
  }

  goToEdit(invoiceId: number) {
    this.router.navigate(['edit-invoice', invoiceId], { relativeTo: this.route });
  }

  deleteInvoice(invoiceId: number) {
    if (!confirm('Bu faturayı silmek istediğinize emin misiniz?')) return;

    this.http.delete(`https://localhost:7206/api/invoice/InvoiceDelete/${invoiceId}`)
      .subscribe({
        next: () => {
          this.invoices = this.invoices.filter(i => i.invoiceId !== invoiceId);
          alert('Fatura silindi.');
        },
        error: (err) => console.error('Fatura silinemedi:', err)
      });
  }
}
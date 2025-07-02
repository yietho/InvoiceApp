import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../../../core/services/auth.service';

@Component({
  standalone: true,
  selector: 'app-invoice-edit',
  imports: [CommonModule, FormsModule],
  templateUrl: './invoice-edit.component.html'
})
export class InvoiceEditComponent implements OnInit {
  private http = inject(HttpClient);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private auth = inject(AuthService);

  invoiceId: number = 0;
  invoice: any = {
    invoiceId: 0,
    customerId: 0,
    userId: 0,
    invoiceNumber: '',
    invoiceDate: new Date().toISOString().slice(0, 10),
    lines: []
  };

  ngOnInit() {
    this.invoiceId = parseInt(this.route.snapshot.paramMap.get('id') || '0', 10);
    if (this.invoiceId > 0) {
      this.loadInvoice();
    }
  }

  loadInvoice() {
    this.http.get<any[]>('https://localhost:7206/api/invoice/InvoiceList')
      .subscribe({
        next: (invoices) => {
          const found = invoices.find(i => i.invoiceId === this.invoiceId);
          if (!found) {
            alert('Fatura bulunamadı.');
            this.router.navigate(['/']);
            return;
          }

          const currentUserId = this.auth.getUserId();
          const currentCustomerId = this.auth.getCustomerId();

          if (found.userId !== currentUserId || found.customerId !== currentCustomerId) {
            alert('Bu faturayı düzenleme yetkiniz yok.');
            this.router.navigate(['/']);
            return;
          }

          // set editable fields
          this.invoice = {
            invoiceId: found.invoiceId,
            customerId: found.customerId,
            userId: found.userId,
            invoiceNumber: found.invoiceNumber,
            invoiceDate: found.invoiceDate.split('T')[0],
            lines: found.lines.map((line: any) => ({
              itemName: line.itemName,
              quentity: line.quentity,
              price: line.price,
              userId: line.userId
            }))
          };
        },
        error: (err) => {
          console.error('Fatura yüklenemedi:', err);
          alert('Fatura verileri alınamadı.');
        }
      });
  }

  addLine() {
    this.invoice.lines.push({ itemName: '', quentity: 1, price: 0, userId: this.auth.getUserId() });
  }

  removeLine(index: number) {
    this.invoice.lines.splice(index, 1);
  }

  submit() {
    this.invoice.userId = this.auth.getUserId();
    this.invoice.customerId = this.auth.getCustomerId();
    this.invoice.lines.forEach((line: any) => {
        line.userId = this.auth.getUserId();
    });

    this.http.put('https://localhost:7206/api/invoice/InvoiceUpdate', this.invoice)
      .subscribe({
        next: () => {
          alert('Fatura başarıyla güncellendi.');
          this.router.navigate(['/invoices']);
        },
        error: (err) => {
          console.error('Fatura güncellenemedi:', err);
          alert('Fatura güncellenemedi.');
        }
      });
  }
}
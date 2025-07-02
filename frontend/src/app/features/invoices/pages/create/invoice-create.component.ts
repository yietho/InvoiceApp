import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../../../core/services/auth.service';
import {  Router } from '@angular/router';


@Component({
  standalone: true,
  selector: 'app-invoice-create',
  imports: [CommonModule, FormsModule],
  templateUrl: './invoice-create.component.html'
})
export class InvoiceCreateComponent {
  private http = inject(HttpClient);
  private authService = inject(AuthService);
  private router = inject(Router);

  invoice = {
    customerId: 0,
    userId: 0,
    invoiceNumber: '',
    invoiceDate: new Date().toISOString().slice(0, 10),
    lines: [
      { itemName: '', quentity: 1, price: 0, userId: 0 }
    ]
  };

  ngOnInit() {
    const userId = this.authService.getUserId();
    const customerId = this.authService.getCustomerId();

    if (!userId || !customerId) {
      alert("Kullanıcı bilgisi bulunamadı. Lütfen tekrar giriş yapın.");
      return;
    }

    this.invoice.userId = userId;
    this.invoice.customerId = customerId;
    this.invoice.lines.forEach(line => line.userId = userId);
  }

  addLine() {
    const userId = this.authService.getUserId() || 0;
    this.invoice.lines.push({ itemName: '', quentity: 1, price: 0, userId });
  }

  removeLine(index: number) {
    this.invoice.lines.splice(index, 1);
  }

  submit() {
    const userId = this.authService.getUserId();
    const customerId = this.authService.getCustomerId();

    if (!userId || !customerId) {
      alert("Kullanıcı bilgisi bulunamadı.");
      return;
    }

    this.invoice.userId = userId;
    this.invoice.customerId = customerId;
    this.invoice.lines.forEach(line => line.userId = userId);

    this.http.post('https://localhost:7206/api/invoice/InvoiceSave', this.invoice)
      .subscribe({
        next: () => {
          alert('Fatura başarıyla eklendi.');
          this.router.navigate(['/invoices']);
        },
        error: (err) => console.error('Fatura oluştururken hata oluştu!', err)
      });
  }
}
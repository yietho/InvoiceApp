import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { InvoiceCreateComponent } from '../../features/invoices/pages/create/invoice-create.component';

export interface Invoice {
  invoiceId: number;
  invoiceNumber: string;
  invoiceDate: string;
  totalAmount: number;
  lineCount: number;
}

@Injectable({ providedIn: 'root' })
export class InvoiceService {
  private apiUrl = 'https://localhost:7206/api/invoice';

  constructor(private http: HttpClient) {}

  getInvoices(): Observable<Invoice[]> {
    return this.http.get<Invoice[]>(`${this.apiUrl}/InvoiceList`);
  }

  deleteInvoice(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/InvoiceDelete/${id}`);
  }

  createInvoice(invoice: InvoiceCreateComponent) {
    return this.http.post('https://localhost:7206/api/invoices', invoice);
  }
}
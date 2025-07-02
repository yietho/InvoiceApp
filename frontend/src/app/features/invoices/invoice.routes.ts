import { Routes } from '@angular/router';
import { InvoiceListComponent } from './pages/list/invoice-list.component';
import { InvoiceCreateComponent } from './pages/create/invoice-create.component';

export const invoiceRoutes: Routes = [
  {
    path: 'invoices',
    children: [
      { path: '', component: InvoiceListComponent },
      { path: 'create-invoice', component: InvoiceCreateComponent },
      {
        path: 'edit-invoice/:id',
        loadComponent: () =>
          import('./pages/edit/invoice-edit.component').then(m => m.InvoiceEditComponent)
      }
    ]
  }
];

import { ApplicationConfig } from '@angular/core';
import { provideRouter, withComponentInputBinding } from '@angular/router';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { authRoutes } from './features/auth/auth.routes';
import { invoiceRoutes } from './features/invoices/invoice.routes';
import { authInterceptor } from './core/interceptors/auth.interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(
      [
        { path: '', redirectTo: 'login', pathMatch: 'full' },
        ...authRoutes,
        ...invoiceRoutes
      ],
      withComponentInputBinding()
    ),
    provideHttpClient(withInterceptors([authInterceptor]))
  ]
};
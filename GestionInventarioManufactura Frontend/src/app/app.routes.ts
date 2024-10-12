import { Routes } from '@angular/router';
import { AuthGuard } from './guard/auth.guard';
import { ProductsModule } from './products/products.module';

export const routes: Routes = [
  { path: 'auth',  loadChildren: () => import('./auth/auth.module').then((m) => m.AuthModule), },
  { path: 'dashboard', canActivate: [AuthGuard],  loadChildren: () => import('./products/products.module').then((m) => m.ProductsModule), },
  { path: '**', redirectTo: '/auth', pathMatch: 'full' },
];

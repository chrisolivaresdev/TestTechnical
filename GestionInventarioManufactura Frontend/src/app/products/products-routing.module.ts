import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products.component';
import { ProductsDahsboardComponent } from './components/products-dahsboard/products-dahsboard.component';
import { AddProductComponent } from './components/add-product/add-product.component';


const routes: Routes = [
  {
    path: '',
    component: ProductsComponent,
    children: [
      {
        path:'products', component: ProductsDahsboardComponent
      },
      {
        path:'add-product',
        component: AddProductComponent
      },
      {
        path:'edit-product/:id',
        component: AddProductComponent
      },
      {
        path:'**', redirectTo: 'products'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }

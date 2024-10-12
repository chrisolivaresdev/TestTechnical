import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { SharedModule } from '../shared/shared.module';
import { ProductsComponent } from './products.component';
import { ProductsDahsboardComponent } from './components/products-dahsboard/products-dahsboard.component';
import { MaterialComponentsModule } from '../shared/material-components/material-components.module';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { AddProductComponent } from './components/add-product/add-product.component';


@NgModule({
  declarations: [ProductsComponent, ProductsDahsboardComponent, AddProductComponent],
  imports: [
    CommonModule,
    ProductsRoutingModule,
    SharedModule,
    MaterialComponentsModule,
    RouterModule,
    ReactiveFormsModule,
  ]
})
export class ProductsModule { }

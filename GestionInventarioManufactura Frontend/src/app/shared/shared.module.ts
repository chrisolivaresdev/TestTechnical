import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { RouterModule } from '@angular/router';
import { MaterialComponentsModule } from './material-components/material-components.module';



@NgModule({
  declarations: [
    NavbarComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    MaterialComponentsModule
  ],
  exports:[
    NavbarComponent,
    MaterialComponentsModule
  ]
})
export class SharedModule { }

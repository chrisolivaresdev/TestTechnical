import { Component, ViewChild, OnInit } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { ProductsService } from '../../../services/products.service';
import { MatSort } from '@angular/material/sort';
import Swal from 'sweetalert2'
import { Router } from '@angular/router';
import { Product } from '../../../interface/interface';


@Component({
  selector: 'app-products-dahsboard',
  templateUrl: './products-dahsboard.component.html',
  styleUrl: './products-dahsboard.component.scss'
})
export class ProductsDahsboardComponent implements OnInit {


   ELEMENT_DATA: Product[] = [

  ];
  displayedColumns: string[] = ['id', 'name', 'typeElaboration', 'status', 'actions'];
  dataSource = new MatTableDataSource();
  product:any
  @ViewChild(MatPaginator) paginator!: MatPaginator;
 @ViewChild(MatSort) sort!: MatSort;

  constructor(private productsService:ProductsService, private router:Router ){

  }
  ngAfterViewInit()
  {

    this.dataSource.sort = this.sort;

    this.paginator.page.subscribe((event) => {
      this.getProducts(event.pageIndex + 1, event.pageSize);
    });
  }

  ngOnInit(): void {


    this.getProducts(1, 5);

    }

    applyFilter(event: Event) {
      const filterValue = (event.target as HTMLInputElement).value;
      this.dataSource.filter = filterValue.trim().toLowerCase();

      if (this.dataSource.paginator) {
        this.dataSource.paginator.firstPage();
      }
    }

 getProducts(pageNumber: number, pageSize: number){
  this.productsService.getPoducts(pageNumber, pageSize).subscribe(resp => {
    this.dataSource.data = resp.data;
    this.paginator.length = resp.totalItems;
    this.paginator.pageIndex = resp.pageNumber - 1;
    this.paginator.pageSize = resp.pageSize;
 })
 }

 changeStatus(id:number){

  Swal.fire({
    title: "Changes status",
    text: "Are you sure you want to change the status??",
    icon: 'question',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    cancelButtonText: 'Cancel',
    confirmButtonText:  "Change"
  }).then((result) => {
    if (result.isConfirmed) {
      this.productsService.changeStatus(id).subscribe(
        { next: (resp) => {
        this.getProducts(1, 5);
        Swal.fire(
          'Change',
          resp.msj,
          'success'
        )
      }, error:(err) => {
        Swal.fire({
          icon: 'error',
          title:  "Upps",
          text:  "Please contact the admin",
        })
      }
    }
      )

    }
  })
 }

 deleteItem(id:number){
  Swal.fire({
    title: 'Remove?',
    text: 'Do you want to remove this product?',
    icon: 'question',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    cancelButtonText: 'Cancel',
    confirmButtonText:  "Removed"
  }).then((result) => {
    if (result.isConfirmed) {
      this.productsService.removeProduct(id).subscribe(
        { next: (resp) => {
          this.getProducts(1, 5);
          Swal.fire(
            "Removed",
            resp.msj,
            'success'
          )
        }, error:(err) => {
          Swal.fire({
            icon: 'error',
            title:  "Upps",
            text:  "Please contact the admin",
          })
        }
      })
    }
  })
 }
 addProduct() {
  this.router.navigate(['/dashboard/add-product']);
}

editProduct(id:number) {
  this.router.navigate([`/dashboard/edit-product/${id}`]);
}


}








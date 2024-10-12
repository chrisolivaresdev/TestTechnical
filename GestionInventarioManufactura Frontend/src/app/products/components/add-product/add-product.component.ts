import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsService } from '../../../services/products.service';
import Swal from 'sweetalert2'
import { switchMap } from 'rxjs';
import { Product } from '../../../interface/interface';

@Component({
  selector: 'app-add-product',

  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.scss'
})
export class AddProductComponent {
  form: FormGroup;
  product!:Product

  constructor(private fb: FormBuilder, private router:Router, private productsService: ProductsService, private activatedRoute:ActivatedRoute) {
    this.form = this.fb.group({
      items: this.fb.array([this.createItem()])
    });
  }

  ngOnInit(): void {

    if(this.router.url.includes('edit-product')){
      this.activatedRoute.params
      .pipe( switchMap( ({id}) => this.productsService.getPoductById(id)))
      .subscribe(
        { next: (resp) => {
        this.product = resp
        this.setFormArrayValues(resp);
      }, error:(err) => {
        this.router.navigate(['/dashboard/products']);
        Swal.fire({
          icon: 'error',
          title:  "Upps",
          text:  "Please contact the admin",
        })
      }
    }
      )
    }
  }

  createItem(): FormGroup {
    return this.fb.group({
      name: ['', Validators.required],
      typeElaboration: ['', Validators.required],
      status: ['', Validators.required]
    });
  }

  get items(): FormArray {
    return this.form.get('items') as FormArray;
  }

  setFormArrayValues(product: Product) {
    const items = this.form.get('items') as FormArray
    items.clear();

    const productFormGroup = this.fb.group({
      name: [product.name, Validators.required],
      typeElaboration: [product.typeElaboration, Validators.required],
      status: [product.status, Validators.required]
    });

    items.push(productFormGroup)
  }

  addItem(): void {
    this.items.push(this.createItem())
  }

  removeItem(index: number): void {
    this.items.removeAt(index)
  }

  onSubmit(): void {
    if(this.form.invalid){
      return
    }

    if(!this.product){
      this.productsService.postProducts(this.form.value.items).subscribe(
        { next: (resp) => {
        this.router.navigate(['/dashboard/products']);
        Swal.fire({
          icon: 'success',
          title:  "Ok!",
          text:  resp.msj,
        })
      }, error:(err) => {
        Swal.fire({
          icon: 'error',
          title:  "Upps",
          text:  "Please contact the admin",
        })
      }
    })
    }else {
      this.productsService.updateProduct(this.product.id,this.form.value.items[0]).subscribe(
        { next: (resp) => {
        this.router.navigate(['/dashboard/products']);
        Swal.fire({
          icon: 'success',
          title:  "Ok!",
          text:  resp.msj,
        })
        }, error:(err) => {
          Swal.fire({
            icon: 'error',
            title:  "Upps",
            text:  "Please contact the admin",
            })
          }
      })
    }
  }

  back(){
    this.router.navigate(['/dashboard/products']);
  }
}

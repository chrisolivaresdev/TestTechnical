import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import Swal from 'sweetalert2'
import { Register } from '../../interface/interface';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {


  registerForm:FormGroup

  constructor( private fb:FormBuilder, private router:Router, private authService : AuthService) {


 this.registerForm = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(3)]],
    email: ['', [Validators.required,  Validators.email]],
    password: ['', [Validators.required]]
  })

  }

  ngOnInit(): void {
    if (this.authService.isAuthenticated()) {
      this.router.navigate(['/dashboard/products']);
    }
  }


  register(): void {

    let UserRegister:Register = {
      name: this.registerForm.controls['name'].value,
      email:this.registerForm.controls['email'].value,
      password:this.registerForm.controls['password'].value,
    }

    this.authService.register(UserRegister).subscribe(
     { next: (resp) => {
      Swal.fire({
        icon:  resp.isSuccess ? 'success': 'question',
        title:  "Ok!",
        text:  resp.msj,
      })
      this.router.navigate(['/login'])
      }, error:(err) => {
        Swal.fire({
          icon: 'error',
          title:  "Upps",
          text: err.msj,
        })
      }}
     )
  }

  login(){
    this.router.navigate(['/auth/login'])
  }

}

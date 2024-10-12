import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import Swal from 'sweetalert2'
import { Login } from '../../interface/interface';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {



  loginForm:FormGroup

  constructor( private fb:FormBuilder, private router:Router, private authService: AuthService) {


 this.loginForm = this.fb.group({
    email: ['', [Validators.required,  Validators.email]],
    password: ['', [Validators.required]]
  })

  }

  ngOnInit(): void {
    if (this.authService.isAuthenticated()) {
      this.router.navigate(['/dashboard/products']);
    }
  }


  login(): void {

    let userLogin: Login = {
      email:this.loginForm.controls['email'].value,
      password:this.loginForm.controls['password'].value,
    }

    this.authService.login(userLogin).subscribe(
     { next: (resp) => {
      Swal.fire({
        icon: 'success',
        title:  "Ok!",
        text: "Login completed",
      })
      this.router.navigate(['/dashboard'])
      }, error:(err) => {
        Swal.fire({
          icon: 'error',
          title:  "Upps",
          text:  'Invalid credentials',
        })
      }}
     )
  }

  register(){
    this.router.navigate(['/auth/register'])
  }
  }

import {Component} from '@angular/core';
import {ApiService} from '../api.service';
import {CustomerService} from '../customer.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {

  email = '';
  password = '';

  constructor(private api: ApiService, private customer: CustomerService, private router: Router) {
  }

  tryLogin() {
    this.api.login(
      this.email,
      this.password
    )
      .subscribe(
        r => {
          debugger;
          if (r.success == true) {
            this.router.navigateByUrl('/dashboard');
          }
        },
        r => {
          debugger;
          alert(r.error.errors[0]);
        });
  }

}

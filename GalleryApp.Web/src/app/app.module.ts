import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { GetExhibitionComponent } from './Components/Exhibition/get-exhibition/get-exhibition.component';
import { ExhibitionsComponent } from './Components/Exhibition/exhibitions/exhibitions.component';
import { CreateComponent } from './Components/Exhibition/create-exhibition/create/create.component';
import { UserComponent } from './Components/User/user/user.component';
import { SignComponent } from './Components/User/sign/sign.component';
import { RegisterComponent } from './Components/User/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    GetExhibitionComponent,
    ExhibitionsComponent,
    CreateComponent,
    UserComponent,
    SignComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'Exhibitions', component: ExhibitionsComponent },
      { path: 'Exhibition/:title', component: GetExhibitionComponent },
      { path: 'Create', component: CreateComponent },
      { path: 'Login', component: SignComponent },
      { path: 'Register', component: RegisterComponent },
      { path: 'Profile', component: UserComponent },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// Component section
import { AppComponent } from './app.component';
import { GetExhibitionComponent } from './Components/Exhibition/get-exhibition/get-exhibition.component';
import { ExhibitionsComponent } from './Components/Exhibition/exhibitions/exhibitions.component';
import { CreateComponent } from './Components/Exhibition/create-exhibition/create/create.component';
import { UserComponent } from './Components/User/user/user.component';
import { SignComponent } from './Components/User/sign/sign.component';
import { RegisterComponent } from './Components/User/register/register.component';
import { SubscriptionsComponent } from './Components/Subscription/subscriptions/subscriptions.component';
import { FilterComponent } from './Components/Filter/filter/filter.component';
import { HeaderComponent } from './Components/Header/header/header.component';

@NgModule({
  declarations: [
    AppComponent,
    GetExhibitionComponent,
    ExhibitionsComponent,
    CreateComponent,
    UserComponent,
    SignComponent,
    RegisterComponent,
    SubscriptionsComponent,
    FilterComponent,
    HeaderComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: ExhibitionsComponent },
      { path: 'Exhibitions', component: ExhibitionsComponent },
      { path: 'Exhibition/:title', component: GetExhibitionComponent },
      { path: 'Create', component: CreateComponent },
      { path: 'Login', component: SignComponent },
      { path: 'Register', component: RegisterComponent },
      { path: 'Profile', component: UserComponent },
      { path: 'Subscriptions', component: SubscriptionsComponent },
      { path: 'Filter', component: FilterComponent },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

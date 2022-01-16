import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { GetExhibitionComponent } from './Components/Exhibition/get-exhibition/get-exhibition.component';
import { ExhibitionsComponent } from './Components/Exhibition/exhibitions/exhibitions.component';
import { CreateComponent } from './Components/Exhibition/create-exhibition/create/create.component';

@NgModule({
  declarations: [
    AppComponent,
    GetExhibitionComponent,
    ExhibitionsComponent,
    CreateComponent,
  ],
  imports: [
    BrowserModule,
    // RouterModule.forRoot([
    //   { path: 'Exhibitions', component: ExhibitionsComponent },
    //   { path: 'Exhibition', component: GetExhibitionComponent },
    //   { path: 'Create', component: CreateComponent },
    // ]),
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

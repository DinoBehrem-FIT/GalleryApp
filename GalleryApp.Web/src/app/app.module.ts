import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { GetExhibitionComponent } from './Components/Exhibition/get-exhibition/get-exhibition.component';
import { ExhibitionsComponent } from './Components/Exhibition/exhibitions/exhibitions.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [AppComponent, GetExhibitionComponent, ExhibitionsComponent],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: 'Exhibitions', component: ExhibitionsComponent },
      { path: 'Exhibition', component: GetExhibitionComponent },
    ]),
    HttpClientModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

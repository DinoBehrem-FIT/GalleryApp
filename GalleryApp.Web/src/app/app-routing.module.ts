import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateComponent } from './Components/Exhibition/create-exhibition/create/create.component';
import { ExhibitionsComponent } from './Components/Exhibition/exhibitions/exhibitions.component';
import { GetExhibitionComponent } from './Components/Exhibition/get-exhibition/get-exhibition.component';

const routes: Routes = [
  { path: 'Exhibitions', component: ExhibitionsComponent },
  { path: 'Exhibition', component: GetExhibitionComponent },
  { path: 'Create', component: CreateComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

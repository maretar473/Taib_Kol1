import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MouseComponent } from './mouse/mouse.component';

const routes: Routes = [{path:"mous",component:MouseComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MouseComponent } from '../mouse/mouse.component';
import { KeyboardsComponent } from '../keyboards/keyboards.component';

const routes: Routes = [
  { path: 'mouses', component: MouseComponent },
  { path: 'keyboards', component: KeyboardsComponent },
  { path: '', redirectTo: '/mouses', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

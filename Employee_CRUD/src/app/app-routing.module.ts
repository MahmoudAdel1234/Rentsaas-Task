import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DisplayAllComponent } from './Components/display-all/display-all.component';
import { AddComponent } from './Components/add/add.component';
import { EditComponent } from './Components/edit/edit.component';

const routes: Routes = [
  {path: '' , redirectTo: 'display-all' , pathMatch: 'full'},
  {path:'display-all' , component: DisplayAllComponent , title: 'All Employees'},
  {path:'add' , component: AddComponent , title: 'Add New Employee'},
  {path:'edit/:empId' , component: EditComponent , title: 'Edit New Employee'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

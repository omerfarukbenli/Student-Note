import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OmerComponent } from './components/omer/omer.component';
import { StudentComponent } from './components/student/student.component';

const routes: Routes = [
  {path:'omer', component:StudentComponent},
  {path:'omers', component:OmerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

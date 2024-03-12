import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsListComponent } from './components/products-list/products-list.component';
import { ProductCreatorComponent } from './components/product-creator/product-creator.component';
import { ProductEditorComponent } from './components/product-editor/product-editor.component';

const routes: Routes = [
  {
    path:"",
    component:ProductsListComponent,
  },
  {
    path:"create",
    component:ProductCreatorComponent
  }
  ,
  {
    path:"update/:id",
    component:ProductEditorComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

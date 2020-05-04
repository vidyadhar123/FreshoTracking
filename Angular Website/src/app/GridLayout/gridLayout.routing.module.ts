import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GridLayoutComponent } from './gridLayout.component';

const routes: Routes = [
    {
      path: '',
      component: GridLayoutComponent
    }
  ];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class gridLayoutRoutingModule { }

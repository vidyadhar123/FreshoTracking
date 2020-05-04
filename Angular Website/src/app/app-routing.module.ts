import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';



const routes: Routes = [
  {
    path: 'Invoicelist',
    loadChildren: () => import('./GridLayout/gridLayout.module').then(m => m.gridLayoutModule)
  },
  {
    path: '',
    loadChildren: () => import('./upload document/upload.module').then(m => m.UploadModule)
  },
]


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

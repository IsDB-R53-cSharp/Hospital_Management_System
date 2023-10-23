import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BedComponent } from './componenets/bed/bed.component';
import { PreoperativeDiagnosisComponent } from './componenets/preoperative-diagnosis/preoperative-diagnosis.component';
import { SurgeryComponent } from './componenets/surgery/surgery.component';
import { WardCabinComponent } from './componenets/ward-cabin/ward-cabin.component';
import { NurseComponent } from './componenets/nurse/nurse.component';
import { DoctorComponent } from './componenets/doctor/doctor.component';
import { PageNotFoundComponent } from './modules/deshboard/page-not-found/page-not-found.component';
import { DepartmentComponent } from './modules/department/department.component';
import { WasteManagementComponent } from './componenets/waste-management/waste-management.component';
import { UnidentifiedDeadBodyComponent } from './componenets/unidentified-dead-body/unidentified-dead-body.component';
import { DrawerComponent } from './componenets/drawer/drawer.component';
import { ServiceComponent } from './componenets/service/service.component';
import { TakenServicesComponent } from './componenets/taken-services/taken-services.component';


const routes: Routes = [
  {path:'bed',component:BedComponent},
  {path:'preoperativeDiagnosis',component:PreoperativeDiagnosisComponent},
  {path:'surgery',component:SurgeryComponent},
  {path:'wardCabin',component:WardCabinComponent},
  {path:'nurse',component:NurseComponent},
  { path: 'doctor', component: DoctorComponent },
  { path: 'UNFDB', component: UnidentifiedDeadBodyComponent },
  { path: 'WasteManagement', component: WasteManagementComponent },
  { path: 'drawer', component: DrawerComponent },
  { path: 'Service', component: ServiceComponent },
  { path: 'TakenServices', component: TakenServicesComponent },


  { path: "department-designation", component: DepartmentComponent },
  { path: '**', pathMatch: 'full', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

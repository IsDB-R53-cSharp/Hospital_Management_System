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
import { ServiceComponent } from './componenets/service/service.component';
import { TestBillsComponent } from './componenets/test-bills/test-bills.component';
import { TakenServicesComponent } from './componenets/taken-services/taken-services.component';
import { MedicineBillsComponent } from './componenets/medicine-bills/medicine-bills.component';

const routes: Routes = [
  {path:'bed',component:BedComponent},
  {path:'preoperativeDiagnosis',component:PreoperativeDiagnosisComponent},
  {path:'surgery',component:SurgeryComponent},
  {path:'wardCabin',component:WardCabinComponent},
  {path:'nurse',component:NurseComponent},
  { path: 'doctor', component: DoctorComponent },

  { path: 'Service', component: ServiceComponent },
  { path: 'TestBills', component: TestBillsComponent },
  { path: 'TakenServices', component: TakenServicesComponent },
  { path: 'MedicineBills', component: MedicineBillsComponent },

  { path: "department-designation", component: DepartmentComponent },
  { path: '**', pathMatch: 'full', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

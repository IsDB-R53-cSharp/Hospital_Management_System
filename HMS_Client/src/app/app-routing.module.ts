import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BedComponent } from './componenets/bed/bed.component';
import { PreoperativeDiagnosisComponent } from './componenets/preoperative-diagnosis/preoperative-diagnosis.component';
import { SurgeryComponent } from './componenets/surgery/surgery.component';
import { WardCabinComponent } from './componenets/ward-cabin/ward-cabin.component';
import { NurseComponent } from './componenets/nurse/nurse.component';
import { DoctorComponent } from './componenets/doctor/doctor.component';

const routes: Routes = [
  {path:'bed',component:BedComponent},
  {path:'preoperativeDiagnosis',component:PreoperativeDiagnosisComponent},
  {path:'surgery',component:SurgeryComponent},
  {path:'wardCabin',component:WardCabinComponent},
  {path:'nurse',component:NurseComponent},
  {path:'doctor',component:DoctorComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

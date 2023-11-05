import { Component } from '@angular/core';
import { UnIdenfiedDeadBody } from '../../models/un-idenfied-dead-body';
import { UnIdenfiedDeadBodyService } from '../../service/un-idenfied-dead-body.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-unidentified-dead-body',
  templateUrl: './unidentified-dead-body.component.html',
  styleUrls: ['./unidentified-dead-body.component.css']
})
export class UnidentifiedDeadBodyComponent {
  UnIdenfiedDeadBody: any;

  POSTUnIdenfiedDeadBody: UnIdenfiedDeadBody = {
    unIdenfiedDeadBodyID: undefined,
    tagNumber: 0,
    deceasedName: '',
    dateOfDeath: undefined,
    causeOfDeath: ''
  }
  constructor(private UNDFBServices: UnIdenfiedDeadBodyService, private route: Router) { }
  ngOnInit() {
    this.AllUNDFB();
  }
  AllUNDFB() {
    this.UNDFBServices.GetAllUnIdenfiedDeadBody().subscribe(u => {
      this.UnIdenfiedDeadBody = u;
    });
  }
  insertUnIdenfiedDeadBody() {
    if (this.POSTUnIdenfiedDeadBody.unIdenfiedDeadBodyID === undefined) {
      this.UNDFBServices.PostUnIdenfiedDeadBody(this.POSTUnIdenfiedDeadBody).subscribe(u => {
        console.log(u);
        this.route.navigate(['/UNFDB']);
        this.AllUNDFB();
        this.POSTUnIdenfiedDeadBody = {
          unIdenfiedDeadBodyID: undefined,
          tagNumber: 0,
          deceasedName: '',
          dateOfDeath: undefined,
          causeOfDeath: ''
        }
      });
    }
    else {
      this.UpdateUnIdenfiedDeadBody(this.POSTUnIdenfiedDeadBody)
      this.POSTUnIdenfiedDeadBody = {
        unIdenfiedDeadBodyID: undefined,
        tagNumber: 0,
        deceasedName: '',
        dateOfDeath: undefined,
        causeOfDeath: ''
      }
    }
  }

  UpdateUnIdenfiedDeadBody(POSTUnIdenfiedDeadBody: UnIdenfiedDeadBody) {
    this.UNDFBServices.UpdateUnIdenfiedDeadBody(POSTUnIdenfiedDeadBody).subscribe(up => {
      this.AllUNDFB();
    });
  }
  UnIdenfiedDeadBodyDelete(id: number) {
    this.UNDFBServices.DeleteUnIdenfiedDeadBody(id).subscribe(d => {
      this.route.navigate(['/UNFDB']);
      this.AllUNDFB();
    })
  }
  PopulateUnIdenfiedDeadBody(POP: UnIdenfiedDeadBody) { this.POSTUnIdenfiedDeadBody = POP }
}

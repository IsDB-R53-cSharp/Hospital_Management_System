import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Morgue } from '../../models/morgue';
import { MorgueService } from '../../service/morgue.service';

@Component({
  selector: 'app-morgue',
  templateUrl: './morgue.component.html',
  styleUrls: ['./morgue.component.css']
})
export class MorgueComponent {
  morgue: any;

  PostMorgue: Morgue = {
    morgueID: undefined,
    morgueName: '',
    capacity: undefined,
    isolationCapability: true,
    drawers: undefined
  }
  constructor(private MorgueService: MorgueService, private route: Router) { }
  ngOnInit() {
    this.GetAllMorgue();
  }
  GetAllMorgue() {
    this.MorgueService.GetAllMorgue().subscribe(m => {
      this.morgue = m;
    });
  }
  insertMorgue() {
    if (this.PostMorgue.morgueID === undefined) {
      this.MorgueService.PostMorgue(this.PostMorgue).subscribe(m => {
        console.log(m);
        this.route.navigate(['/morgue']);
        this.GetAllMorgue();
        this.PostMorgue = {
          morgueID: undefined,
          morgueName: '',
          capacity: undefined,
          isolationCapability: true,
          drawers: undefined
        }
      });
    }
    else {
      this.UpdateMorgue(this.PostMorgue)
      this.PostMorgue = {
        morgueID: undefined,
        morgueName: '',
        capacity: undefined,
        isolationCapability: true,
        drawers: undefined
      }
    }
  }

  UpdateMorgue(PostMorgue: Morgue) {
    this.MorgueService.UpdateMorgue(PostMorgue).subscribe(m => {
      this.GetAllMorgue();
    });
  }
  MorgueDelete(id: number) {
    this.MorgueService.DeleteMorgue(id).subscribe(m => {
      this.route.navigate(['/morgue']);
      this.GetAllMorgue();
    })
  }
  PopulateMorgue(POP: Morgue) { this.PostMorgue = POP }
}

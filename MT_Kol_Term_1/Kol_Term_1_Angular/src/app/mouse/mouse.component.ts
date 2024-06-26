import { Component, OnInit } from '@angular/core';
import { MouseService, Mouse } from '../mouse/mouse.service';

@Component({
  selector: 'app-mouse',
  templateUrl: './mouse.component.html',
  styleUrls: ['./mouse.component.css']
})
export class MouseComponent implements OnInit {
  mice: Mouse[] = [];
  showForm = false;
  newMouse: Omit<Mouse, 'id'> = { model: '', dpi: 0 };

  constructor(private mouseService: MouseService) {}

  ngOnInit(): void {
    this.loadMice();
  }

  loadMice(): void {
    this.mouseService.getMice().subscribe((data: Mouse[]) => (this.mice = data));
  }

  deleteMouse(id: number): void {
    this.mouseService.deleteMouse(id).subscribe(() => this.loadMice());
  }

  toggleForm(): void {
    this.showForm = !this.showForm;
  }

  addMouse(): void {
    this.mouseService.addMouse(this.newMouse).subscribe(() => {
      this.loadMice();
      this.toggleForm();
      this.newMouse = { model: '', dpi: 0 };
    });
  }
}

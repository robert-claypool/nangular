import { Component, OnInit } from '@angular/core';
import { PageTitleService } from '../../services/page-title.service';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.scss'],
})
export class NotFoundComponent implements OnInit {
  public constructor(private pageTitleService: PageTitleService) {}

  ngOnInit() {
    this.pageTitleService.updateTitle('Page Not Found');
  }
}

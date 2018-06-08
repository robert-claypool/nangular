import { Component, OnInit } from '@angular/core';
import { PageTitleService } from '../../services/page-title.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.scss'],
})
export class WelcomeComponent implements OnInit {
  appName = 'nAngular';

  public constructor(private pageTitleService: PageTitleService) {}

  ngOnInit() {
    this.pageTitleService.updateTitle('Welcome');
  }
}

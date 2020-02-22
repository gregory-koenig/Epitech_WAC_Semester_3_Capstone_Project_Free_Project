import { Input, Component, OnInit } from '@angular/core';
import {HighScores} from "@app/dashboard_admin/dashboard-homepage/HighScores";
import {SocialMedia} from "@app/dashboard_admin/dashboard-homepage/SocialMedia";

@Component({
  selector: 'app-stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.scss']
})
export class StatsComponent implements OnInit {
    @Input() likesFacebook: number;
    @Input() followers: number;
    @Input() likesInstagram: number;

    @Input() HighScores: HighScores;
    @Input() SocialMedia: SocialMedia;

  constructor() {}

  ngOnInit() {
  }

}

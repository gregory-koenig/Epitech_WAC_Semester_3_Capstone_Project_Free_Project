import { Component, OnInit } from '@angular/core';
import {first} from "rxjs/operators";
import {Article} from "@app/_models";
import {ArticleService} from "@app/_services/article.service";

@Component({
    selector: 'app-dashboard-article',
    templateUrl: './dashboard-article.component.html',
    styleUrls: ['./dashboard-article.component.css']
})
export class DashboardArticleComponent implements OnInit {

    public articles: Article[] = [];
    
    constructor(private articleService: ArticleService) { }

    ngOnInit() {
        this.articleService.getAll().pipe(first()).subscribe(articles =>
        {
            this.articles = articles;
        });
    }

}

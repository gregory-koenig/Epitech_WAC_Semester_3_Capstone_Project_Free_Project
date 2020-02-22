import { Component, OnInit } from '@angular/core';
import {ArticleService} from "@app/_services/article.service";
import {CategoryService} from "@app/_services/category.service";
import {first} from "rxjs/operators";
import {ArticleImageService} from "@app/_services/article.image.service";
import {ImageService} from "@app/_services/image.service";

@Component({
    selector: 'app-homepage',
    templateUrl: './homepage.component.html',
    styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

    public articles: object = [];
    constructor(private articleService: ArticleService,
                private categoryService: CategoryService,
                private articleImageService: ArticleImageService,
                private imageService: ImageService) { }

    ngOnInit() {
        this.articleService.getAll().pipe(first()).subscribe(articles => {
            this.articleImageService.getAll().pipe(first()).subscribe(articleImages => {
                this.categoryService.getAll().pipe(first()).subscribe(categories => {
                    articles.forEach(x => {
                        categories.forEach(y => {
                            if (x.categoryId == y.id) {
                                x.category = y.name
                            }
                        });
                        articleImages.forEach(z => {
                            if (x.id == z.articleId) {
                                this.imageService.getById(z.imageId).pipe(first()).subscribe(image => {
                                    x.image = image.picture;
                                });
                            }
                        });
                    });
                    this.articles = articles;
                });
            });
        });
    }
    
    log() {
        console.log(this.articles);
    }

}

import { Component, OnInit } from '@angular/core';
import {ArticleService} from "@app/_services/article.service";
import {first} from "rxjs/operators";
import {ActivatedRoute} from "@angular/router";
import {Article} from "@app/_models";
import {ArticleImageService} from "@app/_services/article.image.service";
import {ImageService} from "@app/_services/image.service";
import {CategoryService} from "@app/_services/category.service";

@Component({
    selector: 'app-article',
    templateUrl: './article.component.html',
    styleUrls: ['./article.component.css']
})
export class ArticleComponent implements OnInit {
    
    public article: Article;
    public articleId: number = parseInt(this.route.snapshot.paramMap.get('id'));

    constructor(private articleService: ArticleService,
                private route: ActivatedRoute,
                private articleImageService: ArticleImageService,
                private imageService: ImageService,
                private categoryService: CategoryService) { }

    ngOnInit() {
        // this.articleService.getById(this.articleId).pipe(first()).subscribe(article => {
        //     this.article = article;
        // });

        this.articleService.getById(this.articleId).pipe(first()).subscribe(article => {
            this.articleImageService.getAll().pipe(first()).subscribe(articleImages => {
                this.categoryService.getAll().pipe(first()).subscribe(categories => {
                    categories.forEach(y => {
                        if (article.categoryId == y.id) {
                            article.category = y.name
                        }
                    });
                    articleImages.forEach(z => {
                        if (article.id == z.articleId) {
                            this.imageService.getById(z.imageId).pipe(first()).subscribe(image => {
                                article.image = image.picture;
                            });
                        }
                    });
                    this.article = article;
                });
            });
        });
    }

}

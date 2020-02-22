import { Component, OnInit } from '@angular/core';
import { HighScores } from './HighScores';
import { SocialMedia } from './SocialMedia';

@Component({
  selector: 'app-dashboard-homepage',
  templateUrl: './dashboard.homepage.component.html',
  styleUrls: ['./dashboard.homepage.component.scss']
})
export class DashboardHomepageComponent implements OnInit {
    public HighScores: HighScores[];
    public SocialMedia: SocialMedia[];

    public likesFacebook: number;
    public followers: number;
    public likesInstagram: number;

    constructor() {
        this.SocialMedia = [
            {
                id: 0,
                number: 2300,
                brand: 'fab fa-facebook-f',
                text: 'J\'aime',
            },
            {
                id: 1,
                number: 534,
                brand: 'fab fa-twitter',
                text: 'Abonnés',
            },
            {
                id: 2,
                number: 121,
                brand: 'fab fa-instagram',
                text: 'J\'aime',
            },
        ];

        this.HighScores = [
            {
                id: 0,
                title: 'John Frank',
                age: 24,
                activity: 'Développeur Back End',
                email: 'johnfrank@gmail.com',
                img: 'https://sguru.org/wp-content/uploads/2017/06/cool-anonymous-profile-pictures-1699946_orig.jpg',
            },
            {
                id: 1,
                title: 'Mark Kjelberg',
                age: 31,
                activity: 'Développeur Fullstack',
                email: 'markkjelberg@gmail.com',
                img: 'http://i63.tinypic.com/fymsnt.png',
            },
            {
                id: 2,
                title: 'Fabrice Lejust',
                age: 19,
                activity: 'Étudiant',
                email: 'fabricelejuste@gmail.com',
                img: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSd8zn4yigldwEVLdwFOSiTbTNucI8RTmPPDeLQP5D7KDWVtaNWCQ',
            },
            {
                id: 3,
                title: 'Lucas Beret',
                age: 22,
                activity: 'Développeur Front End',
                email: 'lucasberet@gmail.com',
                img: 'https://cdn.pixabay.com/photo/2016/08/20/05/38/avatar-1606916_960_720.png',
            },
        ];
    }

  ngOnInit() {
  }

}

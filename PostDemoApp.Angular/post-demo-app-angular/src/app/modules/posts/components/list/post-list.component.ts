import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from "@angular/core";
import { Subscription } from "rxjs";
import { MiscService } from "src/app/modules/shared/services/misc.service";
import { PostService } from "src/app/modules/shared/services/post.service";
import { Post } from "../../interfaces/post";

@Component({
    selector: 'app-post-list',
    templateUrl: 'post-list.component.html',
    styleUrls: [
        'post-list.component.scss'
    ],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class PostListComponent {
    private subscriptions = new Subscription();

    posts: Post[] = [];
    sortedByTitle: boolean = true;
    sortedAlphabetically: boolean = true;

    constructor(private readonly postService: PostService,
        private readonly changeDetectorRef: ChangeDetectorRef,
        private readonly miscService: MiscService) {
        
    }

    ngOnInit() {
        this.getList();
    }

    ngOnDestroy() {
        this.subscriptions.unsubscribe();
    }

    private getList() {
        this.subscriptions.add(this.postService.GetList().subscribe(res => {
            this.posts = res;

            this.performInitialSort();

            this.changeDetectorRef.markForCheck();
        }));
    }

    private performInitialSort() {
        if (this.sortedByTitle) {
            this.sortByTitle(true);
        } else {
            this.sortByAuthor(true);
        }
    }

    deletePost(post: Post){
        this.subscriptions.add(this.postService.Delete(post.id).subscribe(res => {
            this.posts = this.posts.filter(p => p.id != post.id);

            this.changeDetectorRef.markForCheck();
        }))
    }

    updatePost(post: Post){
        this.subscriptions.add(this.postService.Update(post).subscribe(res => {
            let matchingPost = this.posts.find(p => p.id === post.id);
            
            if(matchingPost) {
                this.posts[this.posts.indexOf(matchingPost)] = post;
            }

            this.posts = this.posts.slice();

            this.changeDetectorRef.markForCheck();
        }))
    }

    refreshList() {
        this.subscriptions.add(this.miscService.RefreshData().subscribe(res => {
            this.getList();
        }))
    }

    sortByTitle(isInitialSort: boolean = false) {
        if(this.sortedByTitle && !isInitialSort) {
            this.sortedAlphabetically = !this.sortedAlphabetically;
        } else {
            this.sortedAlphabetically = true;
            this.sortedByTitle = true;
        }

        this.posts.sort((a, b) => {
            return this.sortedAlphabetically ? this.compareStirngs(b.title, a.title) : this.compareStirngs(a.title, b.title); 
        });

        this.posts = this.posts.slice();
        this.changeDetectorRef.markForCheck();
    }

    sortByAuthor(isInitialSort: boolean = false) {
        if(!this.sortedByTitle && !isInitialSort) {
            this.sortedAlphabetically = !this.sortedAlphabetically;
        } else {
            this.sortedAlphabetically = true;
            this.sortedByTitle = false;
        }

        this.posts = this.posts.sort((a, b) => {
            return this.sortedAlphabetically ? this.compareStirngs(b.user?.name, a.user?.name) : this.compareStirngs(a.user?.name, b.user?.name); 
        });

        this.posts = this.posts.slice();
        this.changeDetectorRef.markForCheck();
    }

    private compareStirngs(stringA: string, stringB: string) {
        return stringA.toLocaleLowerCase().localeCompare(stringB.toLocaleLowerCase());
    }
}
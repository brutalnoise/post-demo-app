import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { Subscription } from "rxjs";
import { filter } from "rxjs/operators";
import { PostService } from "src/app/modules/shared/services/post.service";
import { Post } from "../../interfaces/post";

@Component({
    selector: 'app-post-detatils',
    templateUrl: 'post-details.component.html',
    styleUrls: ['post-details.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class PostDetailsComponent {
    private subscriptions = new Subscription();
    private postId: number;

    post: Post;

    constructor(private readonly postService: PostService,
        private readonly changeDetectorRef: ChangeDetectorRef,
        private readonly route: ActivatedRoute) {

    }

    ngOnInit() {
        this.route.params.subscribe((params: Params) => {
            const { id } = params;
            this.postId = id;

            if(this.postId) {
                this.getPost();
            }
        })


    }

    ngOnDestroy() {
        this.subscriptions.unsubscribe();
    }

    getPost() {
        this.subscriptions.add(this.postService.Get(this.postId).subscribe(res => {
            this.post = res;
            this.changeDetectorRef.markForCheck();
        }))
    }
}
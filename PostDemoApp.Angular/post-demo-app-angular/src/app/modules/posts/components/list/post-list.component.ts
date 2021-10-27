import { ChangeDetectionStrategy, Component } from "@angular/core";
import { Subscription } from "rxjs";
import { PostService } from "../../services/post.service";

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
    constructor(private readonly postService: PostService) {
        
    }

    ngOnInit() {
        this.subscriptions.add(this.postService.GetList().subscribe(res => {
            console.log(res);
        }));
    }

    ngOnDestroy() {
        this.subscriptions.unsubscribe();
    }
}
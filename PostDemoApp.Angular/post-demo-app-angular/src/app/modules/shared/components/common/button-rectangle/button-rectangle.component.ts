import { Component, OnInit, Input, Output, EventEmitter, ChangeDetectionStrategy } from '@angular/core';


@Component({
    selector: 'app-button-rectangle',
    templateUrl: './button-rectangle.component.html',
    styleUrls: ['./button-rectangle.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class ButtonRectangleComponent implements OnInit {
    @Input() icon: string;
    @Input() text: string;
    @Input() disabled = false;

    @Output() clicked: EventEmitter<Event> = new EventEmitter();

    constructor() { }

    ngOnInit(): void {
    }

    onClick(e: Event) {
        this.clicked.emit(e);
    }

}

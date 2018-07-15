import * as React from 'react';
import { RouteComponentProps } from 'react-router';

interface CounterState {
    currentCount: number;
}

export class GuestList extends React.Component<RouteComponentProps<{}>, CounterState> {



    constructor() {
        super();
        this.state = { currentCount: 0 };
    }

    public render() {
        return <div>
          <h1>GuestList </h1>
        </div>;
    }

    incrementCounter() {
        this.setState({
            currentCount: this.state.currentCount + 1
        });
    }
}

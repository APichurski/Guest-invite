import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class VisitingCard extends React.Component<RouteComponentProps<{}>, {}> {



    wypelnijCos() {
        var request = new XMLHttpRequest();
        request.open('POST', '/api/2', true);
        request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
        request.send('{"Name": "Kamil","Surname": "sad","Phone": 34432,"WillAttend": true}');
    }

    public render() {
        return <div>
            <h1 onClick={this.wypelnijCos}>Strona z wizytowka do wypelnienia</h1>
        </div>;
    }
}

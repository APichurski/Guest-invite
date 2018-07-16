import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

var i = 0;

export class GuestList extends React.Component<RouteComponentProps<{}>, FetchDataAboutGuests> {
    constructor() {
        super();
        this.state = {
            guests: [],
            loading: true
        };
    }

    componentDidMount() {
        this.fetchDataFromServer();
    }

    private fetchDataFromServer() {

        fetch('api/guest/get-all-guest')
            .then(response => response.json() as Promise<Guest[]>)
            .then(data => {
                console.log(data);
                this.setState({
                    guests: data,
                    loading: false
                });
            });

    }


    private static deleteGuest(z: any) {

        var containerWithElements = z.target.parentElement.parentNode.children;
        var name = containerWithElements[0].innerText;
        var surname = containerWithElements[1].innerText;
        var phone = containerWithElements[2].innerText;
        var attendace = containerWithElements[3].innerText == "true" ? true : false;
        var request = new XMLHttpRequest();

        request.open('POST', '/api/guests/remove', true);
        request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
        request.send('{"Name":"' + name + '", "Surname":"' + surname + '", "Phone":"' + phone + '", "WillAttend":"' + attendace + '" }');
        z.target.parentElement.parentNode.remove();
    }



    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : GuestList.renderGuestTable(this.state.guests);

        return <div>
            <h1>List of all guests</h1>
            {contents}
        </div>;
    }

    private static renderGuestTable(guests: Guest[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Surname</th>
                    <th>Phone</th>
                    <th>Will Attend?</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                {guests.map(guest =>
                    <tr key={i++} >
                        <td>{guest.name}</td>
                        <td>{guest.surname}</td>
                        <td>{guest.phone}</td>
                        <td>{guest.willAttend?"Will attend":"Will not attend"}</td>
                        <td><button type="button" onClick={this.deleteGuest} className="btn btn-danger glyphicon glyphicon-trash"></button></td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

interface Guest {
    id: Object;
    name: string;
    surname: string;
    phone: string;
    willAttend: boolean;
}

interface FetchDataAboutGuests {
    guests: Guest[];
    loading: boolean
}

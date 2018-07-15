import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchDataAboutGuests {
    guests: Guest[];
    loading: boolean;
}

var i = 0;

function deleteGuest(z: any) {

    z = z.target.parentElement.parentNode.children;

    var name = z[0].innerText;
    var surname = z[1].innerText;
    var phone = z[2].innerText;
    var attendace = z[3].innerText == "true" ? true : false;

    

    var request = new XMLHttpRequest();
    request.open('POST', '/api/guests/remove', true);
    request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');


    request.onload = function () {
      // do something to response
      // console.log(request.responseText);
    };

   request.send('{"Name":"' + name + '", "Surname":"' + surname + '", "Phone":"' + phone + '", "WillAttend":"' + attendace + '" }');
}


export class GuestList extends React.Component<RouteComponentProps<{}>, FetchDataAboutGuests> {
    constructor() {
        super();
        this.state = {
            guests: [],
            loading: true
        };


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
                    <tr  key={i++} >
                        <td>{guest.name}</td>
                        <td>{guest.surname}</td>
                        <td>{guest.phone}</td>
                        <td>{JSON.stringify(guest.willAttend)}</td>
                        <td><button type="button" onClick={deleteGuest} className="btn btn-danger"><span className="glyphicon glyphicon-remove"></span></button></td>
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

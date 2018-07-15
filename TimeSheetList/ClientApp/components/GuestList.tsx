import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

interface FetchDataAboutGuests {
    guests: Guest[];
    loading: boolean;
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
                </tr>
            </thead>
            <tbody>
                {guests.map(guest =>
                    <tr key={guest.phone}>
                        <td>{ guest.name }</td>
                        <td>{guest.surname}</td>
                        <td>{guest.phone}</td>
                        <td>{JSON.stringify(guest.willAttend)}</td>
                    </tr>
                )}
            </tbody>
        </table>;
    }
}

interface Guest {
    name: string;
    surname: string;
    phone: number;
    willAttend: boolean;
}

import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import 'isomorphic-fetch';

var i = 0;

export class SearchGuest extends React.Component<RouteComponentProps<{}>, FetchDataAboutGuests> {

    constructor() {
        super();
        this.state = {
            guests: [],
            loading: true,
            name: ""
        };
        this.handleNameChange = this.handleNameChange.bind(this);
        this.fetchDataFromServer = this.fetchDataFromServer.bind(this);
    }


    private fetchDataFromServer() {
        const uri = 'api/guest/?find=' + this.state.name;
        fetch(uri)
            .then(response => response.json() as Promise<Guest[]>)
            .then(data => {
                this.setState({
                    guests: data,
                    loading: false
                });
            });
    }

    handleNameChange(e: any) {
        this.setState({
            name: e.target.value
        });
    }

    public render() {
        let contents = this.state.loading
            ? <p><em>Type search to find guest with specified name</em></p>
            : SearchGuest.renderGuestTable(this.state.guests);

        return <div>
            <h1>Search guest</h1>
            <form>
                <div className="form-group">
                    <label>Name:</label>
                    <input type="text" onChange={this.handleNameChange} className="form-control" id="name" />
                </div>
                <button type="button" onClick={this.fetchDataFromServer} className="btn btn-default">Submit</button>
            </form>
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
                    <tr key={i++} >
                        <td>{guest.name}</td>
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
    id: Object;
    name: string;
    surname: string;
    phone: string;
    willAttend: boolean;
}

interface FetchDataAboutGuests {
    guests: Guest[];
    loading: boolean,
    name: string
}


import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class VisitingCard extends React.Component<RouteComponentProps<{}>, {}> {

    wypelnijCos(z : any) {

       
        var request = new XMLHttpRequest();
        request.open('POST', '/api/2', true);
        request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
        var name = z.target.name.value;
        var surname = z.target.surname.value;
        var phone = z.target.phone.value;
        var attendace = z.target.willAttend.value == "on" ? true : false;
        request.send('{"Name":' + name + ', "Surname":' + surname + ', "Phone":' + phone + ', "WillAttend":'+ attendace + ' }');
    }

    render() {
        return (
            <form onSubmit={this.wypelnijCos} action="#">
                <div className="form-group">
                    <label>Name:</label>
                    <input type="text" className="form-control" id="name"/>
                </div>

                <div className="form-group">
                    <label>Surname:</label>
                    <input type="text" className="form-control" id="surname"/>
                </div>

                <div className="form-group">
                    <label>Phone:</label>
                    <input type="number" className="form-control" id="phone" />
                </div>


                <div className="checkbox">
                 <label><input type="checkbox" id="willAttend"/> I want to come to party!</label>
                  </div>
                <button type="submit" className="btn btn-default">Submit</button>
            </form>
        );
    }


}

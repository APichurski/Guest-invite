import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Ref } from 'react';



export class VisitingCard extends React.Component<RouteComponentProps<{}>, {}> {

    static ButtonForModal1: any;
    constructor(props: any) {
        super(props);
    }

    sendGuesttoServer(z: any) {
        var dataFromForm;
        dataFromForm = z.target.parentElement;

        var request = new XMLHttpRequest();
        request.open('POST', '/api/2', true);
        request.setRequestHeader('Content-Type', 'application/json; charset=UTF-8');
        var name = dataFromForm.name.value;
        var surname = dataFromForm.surname.value;
        var phone = dataFromForm.phone.value;
        var attendace = dataFromForm.willAttend.value == "on" ? true : false;

        //console.log(z.target.parentElement[5].Click);
        //request.onload = function() {
        //    z.target.parentElement[5].Click();
        //    console.log("adsads");
        //    z.target.parentElement.reset();
        //}

        request.onload = () => {
            console.log(request.responseText);
        }

  



        request.send('{"Name":"' + name + '", "Surname":"' + surname + '", "Phone":"' + phone + '", "WillAttend":"' + attendace + '" }');
    }

    render() {
        return (
            <div>
                <form>
                    <div className="form-group">
                        <label>Name:</label>
                        <input type="text" className="form-control" id="name" />
                    </div>

                    <div className="form-group">
                        <label>Surname:</label>
                        <input type="text" className="form-control" id="surname" />
                    </div>

                    <div className="form-group">
                        <label>Phone:</label>
                        <input type="number" className="form-control" id="phone" />
                    </div>


                    <div className="checkbox">
                        <label><input type="checkbox" id="willAttend" /> I want to come to party!</label>
                    </div>
                    <button type="button" onClick={this.sendGuesttoServer} className="btn btn-default" data-toggle="modal" data-target="#exampleModal">Submit</button>
                </form>
       

                <div className="modal fade" id="exampleModal" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div className="modal-dialog" role="document">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title" id="exampleModalLabel">Result</h5>
                                <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div className="modal-body">
                                <span id="ResultModalForGuest">Successfuly executed submit</span>
                             </div>
                            <div className="modal-footer">
                                <button type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        );
    }


}

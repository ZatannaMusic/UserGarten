import React, { Component } from 'react';
import BootstrapTable from 'react-bootstrap-table-next';
import axios from 'axios';
import Title from "./title.component";
import UserEditor from "./user-editor.component";

export default class UserList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            columns: [{
                dataField: 'title',
                text: 'Title',
                sort: true
            }, {
                dataField: 'firstName',
                text: 'First name',
                sort: true
            }, {
                dataField: 'lastName',
                    text: 'Last name',
                sort: true
            }, {
                dataField: 'birthDate',
                text: 'Birth date',
                sort: true
            }, {
                dataField: 'phone',
                text: 'Phone',
                sort: true
            }, /*{
                dataField: 'photo',
                text: 'Photo',
                sort: false
            },*/],
            searchResult: []
        }
    }

    onSearch = () => {
        // Getting parameters
        let firstNameData = localStorage.getItem("usergarten_firstName");
        if (firstNameData != null) {
            var firstName = JSON.parse(firstNameData);
        }
        if (firstName == undefined) {
            firstName = "";
        }

        let lastNameData = localStorage.getItem("usergarten_lastName");
        if (lastNameData != null) {
            var lastName = JSON.parse(lastNameData);
        }
        if (lastName == undefined) {
            lastName = "";
        }

        let maxResultData = localStorage.getItem("usergarten_maxResult");
        if (maxResultData != null) {
            var maxResult = JSON.parse(maxResultData);
        }
        if (maxResult === "all") {
            maxResult = 0;
        }

        // Prepare command
        var apiUrl = process.env.REACT_APP_SAFE_API_URL;
        var command = apiUrl + process.env.REACT_APP_API_OBJECT_NAME;
        var parameters = `?firstName=${firstName}&lastName=${lastName}&maxResult=${maxResult}`;

        // Web API call
        axios.get(command + parameters)
            .then(response => {
                this.setState({ searchResult: response.data });
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    onCreate = () => {
        alert("onCreate()");
    }

    render() {
        return (
            <div>
                <Title search_callback={this.onSearch} create_callback={this.onCreate} />
                <div className="py-3">
                    <BootstrapTable keyField='id'
                        data={this.state.searchResult}
                        columns={this.state.columns} />
                </div>
            </div>
        );
    }
}

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
                dataField: 'first_name',
                text: 'First name',
                sort: true
            }, {
                dataField: 'last_name',
                text: 'Last name',
                sort: true
            }, {
                dataField: 'birth_date',
                text: 'Birth date',
                sort: true
            }, {
                dataField: 'phone',
                text: 'Phone',
                sort: true
            }, {
                dataField: 'photo',
                text: 'Photo',
                sort: false
            },],
            searchResult: []
        }
    }

    onSearch = () => {
        let firstNameData = localStorage.getItem("usergarten_firstName");
        if (firstNameData != null) {
            var firstName = JSON.parse(firstNameData);
        }

        let lastNameData = localStorage.getItem("usergarten_lastName");
        if (lastNameData != null) {
            var lastName = JSON.parse(lastNameData);
        }

        let maxResultData = localStorage.getItem("usergarten_maxResult");
        if (maxResultData != null) {
            var maxResult = JSON.parse(maxResultData);
        }

        alert("onSearch: " + firstName + "|" + lastName + "|" + maxResult);
        /*
        axios.get('/api/v1/evidences')
            .then(response => {
                this.setState({ searchResult: response.data });
            })
            .catch(function (error) {
                console.log(error);
            });
            */
    }

    onCreate = () => {
        alert("onCreate()");
        /*
        axios.get('/api/v1/evidences')
            .then(response => {
                this.setState({ searchResult: response.data });
            })
            .catch(function (error) {
                console.log(error);
            });
            */
    }

    /*
    render() {
        return (
            <div>
                <Title search_callback={this.onSearch} create_callback={this.onCreate} />
                <div className="py-3">
                    <BootstrapTable keyField='_id'
                        data={this.state.searchResult}
                        columns={this.state.columns} />
                </div>
            </div>
        );
    }
    */

    render() {
        return (
            <div>
                <UserEditor />
            </div>
        );
    }
}

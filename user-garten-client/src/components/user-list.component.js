import React, { Component } from 'react';
import BootstrapTable from 'react-bootstrap-table-next';
import axios from 'axios';
import Title from "./title.component";

export default class UserList extends Component {

    constructor(props) {
        super(props);
        this.state = {
            firstName: "",
            lastName: "",
            maxResult: "all",
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

    componentDidMount = () => {
        let firstNameData = localStorage.getItem("usergarten_firstName");
        if (firstNameData != null) {
            let firstName = JSON.parse(firstNameData);
            this.setState({ firstName: firstName });
        }

        let lastNameData = localStorage.getItem("usergarten_lastName");
        if (lastNameData != null) {
            let lastName = JSON.parse(lastNameData);
            this.setState({ lastName: lastName });
        }

        let maxResultData = localStorage.getItem("usergarten_maxResult");
        if (maxResultData != null) {
            let maxResult = JSON.parse(maxResultData);
            this.setState({ maxResult: maxResult });
        }
    }

    getFilterValues = () => {
        let firstNameData = localStorage.getItem("usergarten_firstName");
        if (firstNameData != null) {
            let firstName = JSON.parse(firstNameData);
            this.setState({ firstName: firstName });
        }

        let lastNameData = localStorage.getItem("usergarten_lastName");
        if (lastNameData != null) {
            let lastName = JSON.parse(lastNameData);
            this.setState({ lastName: lastName });
        }

        let maxResultData = localStorage.getItem("usergarten_maxResult");
        if (maxResultData != null) {
            let maxResult = JSON.parse(maxResultData);
            this.setState({ maxResult: maxResult });
        }
    }

    onSearch = () => {
        this.getFilterValues();
        alert("onSearch: " + this.state.firstName + "|" + this.state.lastName + "|" + this.state.maxResult);
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
        this.getFilterValues();
        alert("onCreate: " + this.state.firstName + "|" + this.state.lastName + "|" + this.state.maxResult);
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
}

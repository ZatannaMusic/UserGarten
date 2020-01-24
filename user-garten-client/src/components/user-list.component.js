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

    onSearch = () => {
        axios.get('/api/v1/evidences')
            .then(response => {
                this.setState({ searchResult: response.data });
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    render() {
        return (
            <div>
                <Title callback={this.onSearch} />
                <div className="py-3">
                    <BootstrapTable keyField='_id'
                        data={this.state.searchResult}
                        columns={this.state.columns} />
                </div>
            </div>
        );
    }
}

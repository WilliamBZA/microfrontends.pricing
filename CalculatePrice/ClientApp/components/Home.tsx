import * as React from 'react';
import { RouteComponentProps } from 'react-router';

import { PriceDisplay } from '../pricedisplay';

export class Home extends React.Component<RouteComponentProps<{}>, any> {
    constructor() {
        super();

        this.state = {
            pricing: {}
        };

        fetch('api/Data/?moviedetails=Black Panther')
            .then(response => response.json())
            .then(data => {
                console.log(data);

                this.setState({
                    pricing: {
                        loading: false,
                        totalPrice: data.totalPrice
                    }
                });
            });
    }

    public render() {
        return <div>
            <PriceDisplay pricing={this.state.pricing} />
        </div>;
    }
}
export default function RandomizeOutcomePlugin(elsaStudio) {
    const { eventBus } = elsaStudio;
    eventBus.on('activity-design-displaying', this.onActivityDesignDisplaying);

    this.onActivityDesignDisplaying = context => {
        alert('test');
        return;
        const activityModel = context.activityModel;

        // Only handle RandomizeOutcome activities.
        if (activityModel.type !== 'RandomizeOutcome')
            return;

        const props = activityModel.properties || [];
        const syntax = SyntaxNames.Json;

        // Get the value stored in the `PossibleOutcomes` property.
        // Keep in mind that activity properties are stored in a dictionary of expressions, keyed by syntax.
        const possibleOutcomes = props.find(x => x.name == 'PossibleOutcomes') || { expressions: { 'Json': '[]' }, syntax: syntax };
        const expression = possibleOutcomes.expressions[syntax] || [];

        // Set the outcomes property of the `context` argument to the list of possible outcomes.
        // Due to the way expressions are serialized depending on the syntax used, we need to check for a couple of formats in order to get the array.
        context.outcomes = !!expression['$values'] ? expression['$values'] : Array.isArray(expression) ? expression : parseJson(expression) || [];
    }
}